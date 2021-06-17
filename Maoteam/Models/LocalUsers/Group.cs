using System;

namespace MaoTeam.Models.LocalUsers
{
    public class Group
    {
        /// <summary>
        /// Наименование группы безопасности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уникальный идентификатор группы.
        /// </summary>
        public virtual Guid UID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Group" /> class.
        /// </summary>
        /// <param name="name">Наименование группы безопасности.</param>
        /// <exception cref="System.ArgumentException">name - name</exception>
        public Group(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(name)} is null or empty.", nameof(name));

            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            if (ReferenceEquals(this, obj)) return true;
            Department o = obj as Department;
            return o.UID == this.UID;
        }

        public override int GetHashCode()
        {
            return this.UID.GetHashCode();
        }
    }
}
