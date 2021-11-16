using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using SilverScreenRelics.Models.TransactionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Services
{
    public class TransactionService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        //Create
        public bool CreateTransaction(TransactionsCreate model)
        {
            Transactions entity = new Transactions
            {
                TransactionId = model.TransactionId,
                UserId = model.User,
                ArtItemId = model.ArtItemId,
                ArtItemPrice = model.ArtItemPrice,

            };

            _dbContext.Transactions.Add(entity);
            return _dbContext.SaveChanges() == 1;

        }
        // Get all
        public List<TransactionsDetails> GetAllTransactions()
        {
            {
                var transactionEntities = _dbContext.Transactions.ToList();
                var transactionList = transactionEntities.Select(t => new TransactionDetail
                {
                    TransactionId = t.TransactionId,
                    UserId = t.UserId,
                    ArtItemId = t.ArtItemId,
                    ArtItemPrice = t.ArtItemPrice,

                }).ToList();
                return transactionList;
            }
        }

        //Get (details by id)
        public TransactionsDetails GetartItemById(int transactionId)
        {
            var transactionEntity = _dbContext.Transactions.Find(transactionId);
            if (transactionEntity == null)
                return null;

            var transactionDetail = new TransactionsDetails
            {
                UserId = transactionEntity.UserId,
                ArtItemId = transactionEntity.ArtItemId,
                ArtItemPrice = transactionEntity.ArtItemPrice,

            };
            return transactionDetail;
        }
        //ArtItem Update
        public bool UpdateTransaction(TransactionsUpdate model)
        {
            var transactionEntity = _dbContext.Transactions.SingleOrDefault(e => e.TransactionId == model.TransactionId);

            transactionEntity.TransactionId = model.TransactionId;
            transactionEntity.UserId = model.UserId;
            transactionEntity.ArtItemId = model.ArtItemId;
            transactionEntity.ArtItemPrice = model.ArtItemPrice;


            return _dbContext.SaveChanges() == 1;
        }

        //ArtItem Delete
        public bool DeleteTransaction(int id)
        {
            var transactionEntity = _dbContext.Transactions.SingleOrDefault(e => e.TransactionId == id);

            _dbContext.Transactions.Remove(transactionEntity);
            return _dbContext.SaveChanges() == 1;

        }
    }
}
