1-getting-started
=================

Code from our first technical meetup.

Open the VS solution and run :)
Ensure you have port 87 open.

Try starting a client first (i.e. Second.exe) and the the server (GettingStarted.exe).
Take a moment to think about what that means, and how it differs from raw TCP sockets.

Yes, it's simple.
Yes, the server's running in lock-step and clients are waiting in sync.
Yes, we'll improve on this in future meetups. 

Takeaways
=========
* ZeroMq uses sockets that look like TCP sockets but are packed with awesome.
* Zero does not do durable messaging OOB. 
* Zero gives you building blocks (e.g. sockets) that you plug together in various "patterns"
to achieve various goals.
* Zero enables communication between threads, processes, even machines in a consistent and 
simple manner.
* We looked at REQ-REP, which is a sync client server pattern.
* Zero works over various transports (tcp, ipc[not-on-windows], inproc, etc.).
* Using TCP, with REQ-REP, clients can start before the server without problems.
Using inproc though, the server MUST start before any client.
* Zero's fun. Come along for the next meetup :)

The recording of the meetup is available at http://skillsmatter.com/podcast/design-architecture/getting-started