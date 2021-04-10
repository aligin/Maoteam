using System;
using System.Collections.Generic;

namespace Maoteam.Models.AdUser
{
    public class Department
    {
        /// <summary>
        /// Наименование департамента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Группы по умолчанию, в которые нужно добавить пользователя, при перемещение в подразделение.
        /// </summary>
        public IList<Group> DefaultGroups { get; set; }

        /// <summary>
        /// Guid подразделения.
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Название группы-администратора, которой позволено редактировать пользователя в текущем департаменте.
        /// </summary>
        public string AdminGroupName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Department" /> class.
        /// </summary>
        /// <param name="name">Наименование департамента.</param>
        /// <exception cref="System.ArgumentException">name - name</exception>
        public Department(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(name)} is null or empty.", nameof(name));

            Name = name;
            DefaultGroups = new List<Group>();
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

        public override string ToString()
        {
            return Name;
        }
    }
}
