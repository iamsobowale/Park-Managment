using ParkManagment.DTOs.Ewallet;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
using ParkManagment.Interfaces.Repositries;

namespace ParkManagment.Implementation.Services
{
    // public class EWalletService:IEWalletService
    // {
    //     private IEwalletRepository _ewallet;
    //
    //     public EWalletService(IEwalletRepository ewallet)
    //     {
    //         _ewallet = ewallet;
    //     }
    //
    //     public EwalletResponseModel Create(EwalletRequestModel wallet)
    //     {
    //         var wallets = new EWallet()
    //         {
    //             Balance = wallet.Balance,
    //             DriverId = wallet.DriverId
    //         };
    //         _ewallet.Create(wallets);
    //         return new EwalletResponseModel()
    //         {
    //             Data = new EwalletDto()
    //             {
    //                 Balance = wallet.Balance,
    //             }
    //         };
    //     }
    //
    //     public EwalletResponseModel Update(EwalletRequestModel wallet)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Delete(int id)
    //     {
    //         var get = _ewallet.Get(id);
    //         if (get==null)
    //         {
    //             return false;
    //         }
    //
    //         _ewallet.Delete(id);
    //         return true;
    //     }
    //
    //     public EwalletResponseModel Get(int id)
    //     {
    //         var get = _ewallet.Get(id);
    //         if (get==null)
    //         {
    //             return new EwalletResponseModel()
    //             {
    //                 Message = "Wallet not Found",
    //                 Status = false
    //             };
    //         }
    //
    //         return new EwalletResponseModel()
    //         {
    //             Message = "Wallet Found",
    //             Status = true,
    //             Data = new EwalletDto()
    //             {
    //                 Id = get.DriverId,
    //                 Balance = get.Balance,
    //                 DriverName = get.Driver.FirstName
    //             }
    //         };
    //     }
    // }
}