using System;
using System.ComponentModel.DataAnnotations;

namespace BitbargBackendTest.Models.Entities
{
    public class ToDo : BaseEntity
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "فیلد عنوان اجباری است")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "عنوان باید بین 3 تا 50 کاراکتر باشد")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        [Required(ErrorMessage = "فیلد تاریخ اجباری است")]
        public DateTime TimeToDo { get; set; }
    }
}
