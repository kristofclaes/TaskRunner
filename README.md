## Description
TaskRunner is a small library to run tasks in a console application.

I often add a console application project to solutions I'm working on. I use this console application to execute simple tasks like emptying the test database, seeding the test database with test data, creating test files, ... With this TaskRunner I can skip the repetitive parts and just add tasks in a very simple way.

## How to use
  1. Download the source and build it (a NuGet package is on its way)
  2. Create a new Console Application and add TaskRunner as a reference
  3. Create a class implementing the `ITask` interface for each task you want to be able to execute
  4. Add the code the task should execute to the `Run` method
  5. Optionally, decorate the class with a `[TaskDescription("A name for the task","A description for the task")]` attribute
  6. Add this code to the `Main` method of your Console Application: `var runner = new Runner(); runner.Go();`
  7. That's it!

You can also take a look at the sample application I have included.