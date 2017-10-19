using System;
using System.Collections.Generic;
using System.Linq;
using Paradigm.ORM.Data.Database;
using Paradigm.ORM.Data.Descriptors;

namespace Paradigm.ORM.Data.Mappers.Generic
{
    /// <inheritdoc />
    /// <summary>
    /// Provides a way to map from a <see cref="T:Paradigm.ORM.Data.Database.IDatabaseReader" /> to a known object type.
    /// </summary>
    /// <typeparam name="TEntity">A type containing mapping information.</typeparam>
    /// <seealso cref="T:Paradigm.ORM.Data.Mappers.DatabaseReaderMapper" />
    /// <seealso cref="T:Paradigm.ORM.Data.Mappers.Generic.IDatabaseReaderMapper`1" />
    public partial class DatabaseReaderMapper<TEntity> : DatabaseReaderMapper, IDatabaseReaderMapper<TEntity> where TEntity : new()
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Paradigm.ORM.Data.Mappers.DatabaseReaderMapper" /> class.
        /// </summary>
        /// <param name="connector">The connector.</param>
        /// <inheritdoc />
        public DatabaseReaderMapper(IDatabaseConnector connector) : base(connector, new CustomTypeDescriptor(typeof(TEntity)))
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///  Initializes a new instance of the <see cref="T:Paradigm.ORM.Data.Mappers.DatabaseReaderMapper" /> class.
        /// </summary>
        /// <param name="connector">A reference to a database connector.</param>
        /// <param name="descriptor">A column property descriptor collection to extract mapping information.</param>
        /// <exception cref="T:System.ArgumentNullException"></exception>
        public DatabaseReaderMapper(IDatabaseConnector connector, IColumnPropertyDescriptorCollection descriptor) : base(connector, descriptor)
        {
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor), $"{nameof(descriptor)} can not be null.");

            if (descriptor.Type != typeof(TEntity))
                throw new ArgumentException($"The {nameof(TableTypeDescriptor)} inner {nameof(Type)} is not {nameof(TEntity)}.");
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        /// <summary>
        /// Gets a list of <see cref="!:TEntity" /> mapped from a database reader.
        /// </summary>
        /// <param name="reader">A database reader cursor.</param>
        /// <returns>A list of <see cref="!:TEntity" />.</returns>
        public new List<TEntity> Map(IDatabaseReader reader)
        {
            return base.Map(reader).Cast<TEntity>().ToList();
        }

        #endregion

        #region Protected Methods

        /// <inheritdoc />
        /// <summary>
        /// Creates a new instance of <see cref="!:TEntity" />.
        /// </summary>
        /// <returns>New instance of <see cref="!:TEntity" />.</returns>
        protected override object CreateInstance()
        {
            return new TEntity();
        }

        #endregion
    }
}