## Description
TaskRunner is a small library to run tasks in a console application.

## How to use
 1. Download the source and build it (a NuGet package is on its way)
 2. Create a new Console Application and add TaskRunner as a reference
 3. Create a class implementing the `ITask` interface for each task you want to be able to execute
 4. Add the code the task should execute to the `Run` method
 5. Optionally, decorate the class with a `[TaskDescription("A description for the task")]` attribute
 6. Add this code to the `Main` method of your Console Application: `var runner = new Runner(); runner.Go();`
 7. That's it!