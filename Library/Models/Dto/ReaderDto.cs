using System;
using System.Collections.Generic;
using Library.Models.Library;

namespace Library.Models.Dto
{
    /// <summary>
    /// Читатель
    /// </summary>
    public class ReaderDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// ФИО читателя
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
