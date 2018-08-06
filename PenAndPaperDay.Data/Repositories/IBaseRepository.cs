using System.Collections;
using System.Collections.Generic;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface IBaseRepository<T, U>
        where T : Entity
        where U : Mapping
    {
        /// <summary>
        /// Finds an object instance by its primary key.
        /// </summary>
        /// <param name="id">ID value</param>
        /// <returns>The instance found</returns>
        U GetById(object id);

        /// <summary>
        /// Returns all items
        /// </summary>
        /// <returns>all items</returns>
        IList<U> GetAll();

        /// <summary>
        /// Adds a new item to the DB and save the changes
        /// </summary>
        /// <param name="entityDTO">object to save</param>
        /// <returns>The created object with Id</returns>
        U Insert(U entityDTO);

        /// <summary>
        /// Adds a new item to the DB and save the changes
        /// </summary>
        /// <param name="entityDTO">object list to save</param>
        /// <returns>The created object with Id</returns>
        IList<U> Insert(IList<U> entityDTO);

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="entityDTO">object to save</param>
        /// <returns>The created object with Id</returns>
        U Update(U entityDTO);

        /// <summary>
        /// Deletes an existing entity
        /// </summary>
        /// <param name="entityDTO">object to delete</param>
        /// <returns>Returns true if deleted</returns>
        bool Delete(U entityDTO);

        /// <summary>
        /// Deletes an existing entity
        /// </summary>
        /// <param name="entityDTO">list of objects to delete</param>
        /// <returns>Returns true if deleted</returns>
        bool Delete(IList<U> entityDTO);
    }
}
