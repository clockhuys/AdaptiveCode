using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud;

namespace ConsoleUIDecorators
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>
    {
        public DeleteConfirmation(IDelete<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Delete(TEntity entity)
        {
            Console.WriteLine("Are you sure you want to delete the entity? [y/N]");
	        var keyInfo = Console.ReadKey();
			if (keyInfo.Key == ConsoleKey.Y)
            {
                decoratedCrud.Delete(entity);
            }
        }

        private readonly IDelete<TEntity> decoratedCrud;
    }
}
