using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MyTaskPlanner
{
    /// <summary>
    /// Represents a string tag to make easy string sorting.
    /// </summary>
    [Serializable]
    public struct TextTag
    {
        /// <summary>
        /// The color of the tag.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        [Key]
        [Required]
        [StringLength(24)]
        public string Name { get; set; }
    }
}