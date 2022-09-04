using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Library
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование книги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Артикул
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Количество экземпляров
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime? DeleteDateTime { get; set; }

        public ICollection<Register> Registers { get; set; } = new List<Register>();
    }
}
