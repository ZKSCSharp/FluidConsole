# FluidConsole

> A lightweight, modular, and fully customizable Console Manager for .NET applications.
> -
> Event-driven, scalable, and developer-friendly.



---



## ✨ Features

- 📜 **Logging** system with different log types (Default, Success, Info, Warn, Error, Critical)

- 🛠️ **Dynamic Debug** with automatic execution and result catching

- 🎨 **Custom Console Coloring** (foreground/background)

- 💓 **Input Reading** simplified

- ⚙️ **Dynamic Event Registration** (custom handlers support)

- 🧹 **Modular Extensions** ready

- 🚀 **Batch Invocation** of multiple handlers



---



## 📦 Installation

```bash

git clone https://github.com/your-username/FluidConsole.git

```

Puis ajoute le projet comme référence dans ton projet .NET.



---



## 🧀 Quick Start



### 1. Log a message

```csharp

FConsole.Log("Hello World!");

```



### 2. Log with a custom log type

```csharp

FConsole.Log("System Boot", "Boot sequence completed.", FConsole.LogType.SUCCESS);

```



### 3. Read an input

```csharp

string userInput = FConsole.Read();

```



### 4. Debug a method dynamically

```csharp

string TestMethod() => "Debugging successful!";

FConsole.Debug(TestMethod, "TestMethod");

```



---



## ⚡ Dynamic Event System



### Example — Create a custom handler



**1. Create a Dynamic Handler:**

```csharp

public static void CustomLogger(LogEvent evt)

{

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine($"[CUSTOM] - {evt.Input}");

}

```



**2. Register the handler dynamically:**

```csharp

ConsoleEventHub.RegisterHandlers<LogEvent>("CustomLogger", CustomLogger);

```



**3. Invoke manually:**

```csharp

ConsoleEventHub.Invoke(new LogEvent("Dynamic Log Event", FConsole.LogType.INFO), "CustomLogger");

```



---



## 🛠️ Register multiple handlers at once



```csharp

var handlers = new Dictionary<string, ConsoleEventHandler<LogEvent>>

{

    { "LoggerA", evt => Console.WriteLine($"[LoggerA]: {evt.Input}") },

    { "LoggerB", evt => Console.WriteLine($"[LoggerB]: {evt.Input.ToUpper()}") }

};



ConsoleEventHub.RegisterHandlerBatch(handlers);

```



---



## 📚 FConsole Public API



| Method | Description |

|:-------|:------------|

| `FConsole.Log(string message)` | Write a log message |

| `FConsole.Log(string sender, string input, LogType type = LogType.INFO)` | Write a log message with a severity. |

| `FConsole.Read()` | Read user input from console. |

| `FConsole.Debug(Delegate method, string methodName)` | Dynamically execute and log a method, util for quick debug. |

| `FConsole.SetForeGroundColor(ConsoleColor color)` | Set the console text color. |

| `FConsole.SetBackGroundColor(ConsoleColor color)` | Set the console background color. |



---



## 🍿 License

[MIT License](LICENSE)



---



## 💖 Contributing

> Feel free to fork the project, submit issues, or propose enhancements.  

> _FluidConsole_ is designed to be **community-driven**.  

> Contributions are welcome!



---



# 🚀 Let’s build the future of .NET Console together!

