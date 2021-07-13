# MGS.CommandServo.dll

## Summary

- A framework for command servo system.

## Environment

- .Net Framework 3.5 or above.

## Dependence

- System.dll
- MGS.DesignPattern.dll
- MGS.Logger.dll

## Demand

- Read command buffer from IO.
- Parse buffer to command.
- Execute command by unit.

## Implemented

- Interface.

  ```C#
  /// <summary>
  /// Interface for Command IO.
  /// </summary>
  public interface ICommandIO{}
  
  /// <summary>
  /// Interface for Command parser.
  /// </summary>
  public interface ICommandParser{}
  
  /// <summary>
  /// Interface for Command Unit.
  /// </summary>
  public interface ICommandUnit{}
  ```

- Command.

  ```C#
  /// <summary>
  /// Command content.
  /// </summary>
  public struct Command{}
  ```
  
- Unit.

  ```C#
  /// <summary>
  /// Command unit.
  /// </summary>
  public abstract class CommandUnit : ICommandUnit{}
  ```
  
- Manager.

  ```C#
  /// <summary>
  /// Manager of Commands.
  /// </summary>
  public class CommandManager : ICommandManager{}
  
  /// <summary>
  /// Manager of Command units.
  /// </summary>
  public class CommandUnitManager : ICommandUnitManager{}
  ```

- Processor.

  ```C#
  /// <summary>
  /// Command servo processor.
  /// </summary>
  public sealed class CommandServoProcessor : SingleTimer<CommandServoProcessor>, ICommandServoProcessor{}
  ```

## Usage

- Implement interfaces.

  ```C#
  
  ```
  
- Construct command manager.

  ```c#
  
  ```
  
- Construct command unit manager and Register units.

  ```C#
  
  ```

- Initialize command servo processor.

  ```C#
  
  ```
  
------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com