using System;
using System.Collections.Generic;

namespace Library.Models.Library
{
    /// <summary>
    /// Читатель
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО читателя
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime? DeleteDateTime { get; set; }

        public ICollection<Register> Registers { get; set; } = new List<Register>();
    }
}
