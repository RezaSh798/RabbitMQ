# 📨 Simple RabbitMQ Messaging with .NET

This is a simple .NET solution demonstrating how to send and receive messages using RabbitMQ. The solution consists of two projects:

- 📤 `Producer`: Sends messages to the `news` queue
- 📥 `Consumer`: Receives messages from the `news` queue

---

## 🔧 Prerequisites

- [.NET 6.0 SDK or higher](https://dotnet.microsoft.com/en-us/download)
- [RabbitMQ Server](https://www.rabbitmq.com/download.html)
  - Or run it via Docker:

    ```bash
    docker run -d --hostname my-rabbit --name rabbitmq \
      -p 5672:5672 -p 15672:15672 rabbitmq:3-management
    ```

    RabbitMQ Management UI: [http://localhost:15672](http://localhost:15672)
    - **Username:** guest
    - **Password:** guest

---

## 📁 Project Structure

```
RabbitMqDemo.sln
├── Producer/
│   └── Program.cs
└── Consumer/
    └── Program.cs
```

---

## 🚀 Getting Started

### ▶️ Running the Producer

1. Ensure RabbitMQ is running.
2. Navigate to the `Producer` directory and run:

    ```bash
    dotnet run
    ```

This will publish a new message to the `news` queue every 2 seconds.

### ▶️ Running the Consumer

1. Open a new terminal.
2. Navigate to the `Consumer` directory and run:

    ```bash
    dotnet run
    ```

This will listen for messages on the `news` queue and print them to the console.

---

## ⚙️ Technical Details

- The queue is declared with:
  - `durable = true`: Survives broker restarts
  - `exclusive = false`: Can be accessed by other connections
  - `autoDelete = false`: Won't be deleted automatically

- Messages are published with:
  - `Persistent = true`: Ensures messages are saved to disk

---

## 💡 Notes

- This project is intended for learning and demonstration purposes.
- Feel free to extend it by adding features like:
  - Exchanges and routing
  - Topics and fanout
  - Retry policies and dead-letter queues

---

## 📚 Resources

- [RabbitMQ Tutorials](https://www.rabbitmq.com/getstarted.html)
- [RabbitMQ .NET Client](https://github.com/rabbitmq/rabbitmq-dotnet-client)