using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Context;
using ParkManagment.Entities;
using ParkManagment.Interfaces.Repositries;

// namespace ParkManagment.Implementation.Repositries
// {
//     public class EWalletRepo:IEwalletRepository
//     {
//         private ApplicationContext _context;
//
//         public EWalletRepo(ApplicationContext context)
//         {
//             _context = context;
//         }
//
//         public EWallet Create(EWallet wallet)
//         {
//             _context.EWallets.Add(wallet);
//             _context.SaveChanges();
//             return wallet;
//         }
//
//         public EWallet Update(EWallet wallet)
//         { 
//             _context.EWallets.Update(wallet);
//             _context.SaveChanges();
//             return wallet;
//         }
//
//         public bool Delete(int id)
//         {
//             var get = _context.EWallets.Find(id);
//             _context.EWallets.Remove(get);
//             _context.SaveChanges();
//             return true;
//         }
//
//         public EWallet Get(int id)
//         {
//            var get = _context.EWallets.Include(c => c.Driver).ThenInclude(c => c.Park).SingleOrDefault(c => c.DriverId == id);
//            return get;
//         }
//     }
// }