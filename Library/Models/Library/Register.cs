using System;

namespace Library.Models.Library
{
    /// <summary>
    /// Журнал учета книг
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ID читателя
        /// </summary>
        public Guid ReaderId { get; set; }

        /// <summary>
        /// ID книги
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime TakeDateTime { get; set; }

        /// <summary>
        /// Дата сдачи
        /// </summary>
        public DateTime? GiveDateTime { get; set; }

        public Book Book { get; set; }

        public Reader Reader { get; set; }
    }
}
