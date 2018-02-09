using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
    public static class EntityObjectExtensions
    {
        //public static bool IsModified(this EntityObject entity)
        //{
        //    if (entity == null)
        //        return false;

        //    //Can't get the object state for an added or detached object, so just return true
        //    // since any new object is by definition a modification
        //    if (entity.IsNew()) 
        //        return true;

        //    //If the context can't be retrieved from the object, return that it has been modified,
        //    // as the likely scenario is that the object is detached (which should have been handled
        //    // by the IsNew case above)
        //    ObjectContext context = entity.GetObjectContextFromEntity();
        //    if (context == null)
        //        return true;

        //    return entity.IsModified(context);
        //}

        public static bool IsModified(this EntityObject entity, ObjectContext context)
        {
            if (entity == null)
                return false;

            //Can't get the object state for an added or detached object, so just return true
            // since any new object is by definition a modification
            if (entity.IsNew())
                return true;

            //Check the actual field values to see if something changed, because the EntityState value
            //stays as Modified even if a field value has been restored to its prior value
            ObjectStateEntry entry = context.ObjectStateManager.GetObjectStateEntry(((IEntityWithKey)entity).EntityKey);
            for (int field = 0; field < entry.OriginalValues.FieldCount; field++) {
                if (!entry.CurrentValues[field].Equals(entry.OriginalValues[field])) {
                    return true;
                }
            }
            return false;
        }

        //https://stackoverflow.com/a/43667414/3610417
        //For me this doesn't work, _entityWrapper field returns null every time.  Nice idea if it would work...
        private static ObjectContext GetObjectContextFromEntity(this object entity)
        {
            var field = entity.GetType().GetField("_entityWrapper");

            if (field == null)
                return null;

            var wrapper = field.GetValue(entity);
            var property = wrapper.GetType().GetProperty("Context");
            var context = (ObjectContext)property.GetValue(wrapper, null);

            return context;
        }

        //public static bool IsModified<TEntity>(this IEnumerable<TEntity> entities) where TEntity : EntityObject
        //{
        //    if (entities.Any(e => e.IsNew() || e.IsDeleted()))
        //        //Any new or deleted record is a modification
        //        return true;

        //    ObjectContext context = entities.First().GetObjectContextFromEntity();
        //    return entities.IsModified(context);
        //}

        public static bool IsModified<TEntity>(this IEnumerable<TEntity> entities, ObjectContext context) where TEntity : EntityObject
        {
            //Deleted entities are no longer in the collection directly, but are still tracked by the object state manager
            bool deleted = context.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Deleted).Any();

            if (deleted || entities.Any(e => e.IsNew()))
                //Any new or deleted record is a modification
                return true;

            var modified = false;
            foreach (var entity in entities) {
                modified = entity.IsModified(context);
                if (modified) {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDeleted(this EntityObject entity)
        {
            if (entity == null)
                return false;

            //Deleted means the object has been flagged for deletion but not yet removed from the db
            return ((entity.EntityState & System.Data.Entity.EntityState.Deleted) == System.Data.Entity.EntityState.Deleted);
        }

        public static bool IsNew(this EntityObject entity)
        {
            if (entity == null)
                return false;

            //Detached or added means the entity is not committed to the db
            return (((entity.EntityState & System.Data.Entity.EntityState.Added) == System.Data.Entity.EntityState.Added)
                || ((entity.EntityState & System.Data.Entity.EntityState.Detached) == System.Data.Entity.EntityState.Detached));
        }
    }
}
