using System;

namespace Library.Models.Dto
{
    public class ReaderReg
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
        /// Книга
        /// </summary>
        public string[] BookNames { get; set; } = Array.Empty<string>();
    }
}
