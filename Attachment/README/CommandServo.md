[TOC]

﻿# MGS.CommandServo.dll

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

- Implement interfaces base your business logic.

  ```C#
  //Implement ICommandIO.
  public class CommandIO : ICommandIO
  {
      public byte[] ReadBuffer()
      {
          //TODO...
          return null;
      }
  
      public void WriteBuffer(byte[] buffer)
      {
          //TODO...
      }
  }
  
  //Implement ICommandParser.
  public class CommandParser : ICommandParser
  {
      public byte[] ToBuffer(Command Command)
      {
          //TODO...
          return null;
      }
  
      public IEnumerable<Command> ToCommands(byte[] buffer)
      {
          //TODO...
          return null;
      }
  }
  
  //Implement ICommandUnit.
  public class MyCommandUnit : CommandUnit
  {
      public override void Execute(params object[] args)
      {
          //TODO...
      }
  }
  ```
  
- Construct command manager.

  ```c#
  var cmdIO = new CommandIO();
  var cmdParser = new CommandParser();
  var cmdManager = new CommandManager(cmdIO, cmdParser);
  ```
  
- Construct command unit manager and Register units.

  ```C#
  var unitManager = new CommandUnitManager();
  var unit_0 = new MyCommandUnit();
  unitManager.RegisterUnit(unit_0);
  ```

- Initialize command servo processor.

  ```C#
  //Processor cruise starts after initialized.
  CommandServoProcessor.Instance.Initialize(cmdManager, unitManager);
  ```
  
------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com