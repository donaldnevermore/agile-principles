﻿namespace AgilePrinciples.Visitor;

public class ErnieModem : Modem {
    public void Dial(string pno) {
    }

    public void Hangup() {
    }

    public void Send(char c) {
    }

    public char Recv() {
        return (char)0;
    }

    public void Accept(ModemVisitor v) {
        v.Visit(this);
    }

    public string InternalPattern { get; set; } = "";
}
