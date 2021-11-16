using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using SilverScreenRelics.Models;
using SilverScreenRelics.Models.ArtItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Services
{
    public class ArtItemService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        //Create
        public bool CreateArtItem(ArtItemCreate model)
        {
            ArtItem entity = new ArtItem
            {
                ArtItemTitle = model.ArtItemTitle,
                ArtItemDescription = model.ArtItemDescription,
                ArtItemPrice = model.ArtItemPrice,
            };

            _dbContext.ArtItemsSell.Add(entity);
            return _dbContext.SaveChanges() == 1;

        }
        // Get all
        public List<ArtItemDetail> GetAllArtItems()
        {
            {
                var artItemsEntities = _dbContext.ArtItemsSell.ToList();
                var artItemList = artItemsEntities.Select(a => new ArtItemDetail
                {
                    ArtItemTitle = a.ArtItemTitle,
                    ArtItemDescription = a.ArtItemDescription,
                    ArtItemPrice = a.ArtItemPrice,
                    IsActive = a.IsActive,
                    CreatedUtc = a.CreatedUtc,
                    ModifiedUtc = a.ModifiedUtc
                }).ToList();
                return artItemList;
            }
        }

        //Get (details by id)
        public ArtItemDetail GetartItemById(int artItemId)
        {
            var artItemEntity = _dbContext.ArtItemsSell.Find(artItemId);
            if (artItemEntity == null)
                return null;

            var artItemDetail = new ArtItemDetail
            {
                ArtItemTitle = artItemEntity.ArtItemTitle,
                ArtItemDescription = artItemEntity.ArtItemDescription,
                IsActive = artItemEntity.IsActive,
                CreatedUtc = artItemEntity.CreatedUtc,
                ModifiedUtc = artItemEntity.ModifiedUtc
            };
            return artItemDetail;
        }
        //ArtItem Update
        public bool UpdateArtItem(ArtItemUpdate model)
        {
            var artItemEntity = _dbContext.ArtItemsSell.SingleOrDefault(e => e.ArtItemId == model.ArtItemId);

            artItemEntity.ArtItemTitle = model.ArtItemTitle;
            artItemEntity.ArtItemDescription = model.ArtItemDescription;
            artItemEntity.ArtItemPrice = model.ArtItemPrice;

            return _dbContext.SaveChanges() == 1;
        }

        //ArtItem Delete
        public bool DeleteArtItem(int id)
        {
            var artItemEntity = _dbContext.ArtItemsSell.SingleOrDefault(e => e.ArtItemId == id);

            _dbContext.ArtItemsSell.Remove(artItemEntity);
            return _dbContext.SaveChanges() == 1;

        }
    }

}
