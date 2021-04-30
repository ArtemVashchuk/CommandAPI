using System.Collections.Generic;
using System.Linq;
using CommandAPI.Models;
using System;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;

        public SqlCommandAPIRepo(CommandContext context) => _context = context;

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCOmmands() => _context.CommandItems.ToList();

        public Command GetCommandById(int id) => _context.CommandItems.FirstOrDefault(c => c.Id == id);

        public void UpdateCommand(Command cmd)
        {
            // stub for another ORM implementation
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}