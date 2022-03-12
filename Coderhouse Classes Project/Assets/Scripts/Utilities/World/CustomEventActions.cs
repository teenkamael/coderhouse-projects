using System;

public static class CustomEventActions
{
    public static Action<Task> TaskCompleted;

    public static Action<WorldEvent> ControllerEventToExecute;


}
