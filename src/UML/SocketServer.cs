using System.Net;
using System.Net.Sockets;

namespace AgilePrinciples.UML;

public interface SocketService {
    void Serve(Socket s);
}

public class SocketServer {
    private readonly TcpListener serverSocket = null;
    private readonly Thread serverThread = null;
    private bool running = false;
    private readonly SocketService itsService = null;
    private readonly List<Thread> threads = new();

    public SocketServer(int port, SocketService service) {
        itsService = service;
        var addr = IPAddress.Parse("127.0.0.1");
        serverSocket = new TcpListener(addr, port);
        serverSocket.Start();
        serverThread = new Thread(new ThreadStart(Server));
        serverThread.Start();
    }

    public void Close() {
        running = false;
        serverThread.Interrupt();
        serverSocket.Stop();
        serverThread.Join();
        WaitForServiceThreads();
    }

    private void Server() {
        running = true;
        while (running) {
            var s = serverSocket.AcceptSocket();
            StartServiceThread(s);
        }
    }

    private void StartServiceThread(Socket s) {
        var serviceThread = new Thread(new ServiceRunner(s, this).ThreadStart());
        lock (threads) {
            threads.Add(serviceThread);
        }
        serviceThread.Start();
    }

    private void WaitForServiceThreads() {
        while (threads.Count > 0) {
            Thread t;
            lock (threads) {
                t = threads[0];
            }

            t.Join();
        }
    }

    internal class ServiceRunner {
        private readonly Socket itsSocket;
        private readonly SocketServer itsServer;

        public ServiceRunner(Socket s, SocketServer server) {
            itsSocket = s;
            itsServer = server;
        }

        public void Run() {
            itsServer.itsService.Serve(itsSocket);
            lock (itsServer.threads) {
                itsServer.threads.Remove(Thread.CurrentThread);
            }
            itsSocket.Close();
        }

        public ThreadStart ThreadStart() {
            return new ThreadStart(Run);
        }
    }
}
