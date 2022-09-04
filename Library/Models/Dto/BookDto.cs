using System;

namespace Library.Models.Dto
{
    public class BookDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid? Id { get; set; }

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
    }
}
