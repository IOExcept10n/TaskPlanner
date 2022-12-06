using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTaskPlanner
{
    /// <summary>
    /// Enumeration that represents task priority level name.
    /// </summary>
    public enum TaskPriority : byte
    {
        /// <summary>
        /// No specified priority of the task.
        /// </summary>
        None,

        /// <summary>
        /// Maximal available priority.
        /// Tasks with it must be completed as soon as possible.
        /// </summary>
        Maximal,

        /// <summary>
        /// Task which is critically valuable to complete.
        /// </summary>
        Critical,

        /// <summary>
        /// Task which should be completed anyway.
        /// </summary>
        VeryHigh,

        /// <summary>
        /// Task which should be completed earlier than other tasks.
        /// </summary>
        High,

        /// <summary>
        /// Task which priority is higher than common.
        /// </summary>
        SlightlyHigh,

        /// <summary>
        /// Common task with default priority.
        /// </summary>
        Normal,

        /// <summary>
        /// Task which you can skip without any problems if you don't have enough time.
        /// </summary>
        Low,

        /// <summary>
        /// Additional task which you can do when you still have enough time to complete.
        /// </summary>
        VeryLow,

        /// <summary>
        /// Task which completion is almost don't needed. It's like a tip mostly.
        /// </summary>
        Minimal,

        /// <summary>
        /// Task to complete it when you have a lot of free time.
        /// </summary>
        FreeTime
    }

    /// <summary>
    /// Enumeration that represents the state of the task in timing organization.
    /// </summary>
    [Flags]
    public enum TimeState
    {
        /// <summary>
        /// No specially qualified modes.
        /// </summary>
        None,

        /// <summary>
        /// Represents if the task has a special completion time which cannot be moved.
        /// </summary>
        UseConcreteDate = 1,

        /// <summary>
        /// Represents if the task has a strict deadline without moving ability.
        /// </summary>
        HasStrictDeadline = 2,
    }

    /// <summary>
    /// Represents a task to make a schedule/daily plan.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Time to complete the task (if available).
        /// </summary>
        public TimeSpan CommonCompletionTime { get; set; }

        /// <summary>
        /// Deadline date until which task should be completed.
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// The exhaustive description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Priority of the task.
        /// </summary>
        public TaskPriority Priority { get; set; } = TaskPriority.Normal;

        /// <summary>
        /// Date since which task starts.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// List of tags of the task.
        /// </summary>
        public List<TextTag> Tags { get; set; }

        /// <summary>
        /// If of the group of the task used to classify it.
        /// </summary>
        public int TaskGroupId { get; set; }

        /// <summary>
        /// Flags to identify task completion mode.
        /// </summary>
        public TimeState TimeFlags { get; set; }

        /// <summary>
        /// The title label of the task.
        /// </summary>
        [StringLength(25, MinimumLength = 3)]
        public string Title { get; set; }
    }
}