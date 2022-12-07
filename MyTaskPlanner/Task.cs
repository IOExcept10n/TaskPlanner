using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MyTaskPlanner
{
    /// <summary>
    /// Represents a task to make a schedule/daily plan.
    /// </summary>
    [Serializable]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Task : ICloneable
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
        /// The status of the task.
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// The list of subtasks which must be completed to complete the task.
        /// </summary>
        public List<Task> Subtasks { get; set; }

        /// <summary>
        /// List of tags of the task.
        /// </summary>
        public List<TextTag> Tags { get; set; }

        /// <summary>
        /// If of the group of the task used to classify it.
        /// </summary>
        public int TaskGroupId { get; set; }

        /// <summary>
        /// Time to repeat the task.
        /// </summary>
        public List<DateTime> TaskRepeatTime { get; set; }

        /// <summary>
        /// Flags to identify task completion mode.
        /// </summary>
        public TimeState TimeFlags { get; set; }

        /// <summary>
        /// The title label of the task.
        /// </summary>
        [StringLength(25, MinimumLength = 3)]
        public string Title { get; set; }

        /// <summary>
        /// Enumeration that represents task priority level name.
        /// <!--Numeration is used to make another priority levels between current.-->
        /// </summary>
        public enum TaskPriority : byte
        {
            /// <summary>
            /// No specified priority of the task.
            /// </summary>
            None,

            /// <summary>
            /// Task to complete it when you have a lot of free time.
            /// </summary>
            FreeTime,

            /// <summary>
            /// Task which completion is almost don't needed. It's like a tip mostly.
            /// </summary>
            Minimal = 23,

            /// <summary>
            /// Additional task which you can do when you still have enough time to complete.
            /// </summary>
            VeryLow = 46,

            /// <summary>
            /// Task which you can skip without any problems if you don't have enough time.
            /// </summary>
            Low = 69,

            /// <summary>
            /// Common task with default priority.
            /// </summary>
            Normal = 92,

            /// <summary>
            /// Task which priority is higher than common.
            /// </summary>
            SlightlyHigh = 115,

            /// <summary>
            /// Task which should be completed earlier than other tasks.
            /// </summary>
            High = 138,

            /// <summary>
            /// Task which should be completed anyway.
            /// </summary>
            VeryHigh = 184,

            /// <summary>
            /// Task which is critically valuable to complete.
            /// </summary>
            Critical = 207,

            /// <summary>
            /// Maximal available priority.
            /// Tasks with it must be completed as soon as possible.
            /// </summary>
            Maximal = 230
        }

        /// <summary>
        /// Represents the status of the task.
        /// </summary>
        public enum TaskStatus
        {
            /// <summary>
            /// Task which is unfinished yet.
            /// </summary>
            Unfinished,

            /// <summary>
            /// A completed task.
            /// </summary>
            Completed,

            /// <summary>
            /// A task which is failed because of time limit or for which manual fail option selected.
            /// </summary>
            Failed,

            /// <summary>
            /// Task some of which subtasks are completed
            /// </summary>
            PartlyCompleted,

            /// <summary>
            /// A canceled task.
            /// </summary>
            Canceled,

            /// <summary>
            /// An exceeded task (can be selected only manually).
            /// </summary>
            Exceeded
        }

        /// <summary>
        /// Represents the state of the task in timing organization.
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

            /// <summary>
            /// Indicates if the task should be repeated every week.
            /// </summary>
            RepeatWeekly = 4
        }

        /// <inheritdoc/>
        public object Clone()
        {
            Task task = MemberwiseClone() as Task;
            task.Subtasks = Subtasks.ConvertAll(x => (Task)x.Clone());
            return task;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Title} [{StartDate}-{Deadline}]: {Status}";
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}