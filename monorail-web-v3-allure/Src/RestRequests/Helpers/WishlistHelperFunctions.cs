using System.Threading;
using static monorail_web_v3.RestRequests.Token;
using static monorail_web_v3.RestRequests.Wishlists;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class WishlistHelperFunctions
    {
        public static void DeleteWishlistItem(string username, string password, string wishlistItemId)
        {
            var token = GenerateToken(username, password);
            DeleteWishlists(token, wishlistItemId);
        }

        public static void AddWishlistItem(string username, string password, string amountAdd, string descriptionAdd,
            string faviconUrlAdd, string imageUrlAdd, string itemUrlAdd, string nameAdd)
        {
            var token = GenerateToken(username, password);
            AddWishlists(token, itemUrlAdd);
        }

        public static void AddPersonalizedWishlistItem(string username, string password, string productUrl,
            string itemName, string itemDescription, string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var token = GenerateToken(username, password);
            AddCustomWishlistItem(token, productUrl, itemName, itemDescription, itemAmount, itemImageUrl,
                itemFavIconUrl);
            WaitUntilItemsAreScraped(token);
        }

        private static void WaitUntilItemsAreScraped(string token)
        {
            string[] wishlistItemsInProgress;
            do
            {
                wishlistItemsInProgress = GetWishlistItemsInProgress(token);
                Thread.Sleep(3000);
            } while (wishlistItemsInProgress.Length > 0);
        }

        public static void AddAndUpdateWishlistItem(string username, string password, string amountAdd,
            string descriptionAdd,
            string faviconUrlAdd, string imageUrlAdd, string itemUrlAdd, string nameAdd)
        {
            var token = GenerateToken(username, password);
            var wishlistItemId = AddWishlists(token, itemUrlAdd);
            Thread.Sleep(60000);
            UpdateWishlists(token, amountAdd, descriptionAdd, faviconUrlAdd, imageUrlAdd, itemUrlAdd, nameAdd,
                wishlistItemId);
        }

        public static void UpdateWishlistItem(string username, string password, string amountAdd, string descriptionAdd,
            string faviconUrlAdd, string imageUrlAdd, string itemUrlAdd, string nameAdd, string wishlistItemId)
        {
            var token = GenerateToken(username, password);
            UpdateWishlists(token, amountAdd, descriptionAdd, faviconUrlAdd, imageUrlAdd, itemUrlAdd, nameAdd,
                wishlistItemId);
        }
    }
}