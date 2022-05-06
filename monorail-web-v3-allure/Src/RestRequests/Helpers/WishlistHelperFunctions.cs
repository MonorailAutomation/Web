using System.Threading;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Database.WishlistItem;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.Token;
using static monorail_web_v3.RestRequests.Endpoints.Monarch.Wishlists;

namespace monorail_web_v3.RestRequests.Helpers
{
    public static class WishlistHelperFunctions
    {
        public static void DeleteWishlistItem(string username, string password, string wishlistItemId)
        {
            var token = GenerateToken(username, password);
            DeleteWishlists(token, wishlistItemId);
        }

        public static void AddPersonalizedWishlistItem(string username, string password, string productUrl,
            string itemName, string itemDescription, string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var token = GenerateToken(username, password);
            AddCustomWishlistItem(token, productUrl, itemName, itemDescription, itemAmount, itemImageUrl,
                itemFavIconUrl);
            WaitUntilItemsAreScraped(token);
        }

        public static void AddEmptyWishlistItem(string username, string productUrl)
        {
            var token = GenerateToken(username, ValidPassword);
            var wishlistItemId = AddCustomWishlistItem(token, productUrl, null, null, null, null, null);
            WaitUntilItemsAreScraped(token);
            ClearWishlistItem(wishlistItemId);
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

        public static void UpdateWishlistItem(string username, string password, string amountAdd, string descriptionAdd,
            string faviconUrlAdd, string imageUrlAdd, string itemUrlAdd, string nameAdd, string wishlistItemId)
        {
            var token = GenerateToken(username, password);
            UpdateWishlists(token, amountAdd, descriptionAdd, faviconUrlAdd, imageUrlAdd, itemUrlAdd, nameAdd,
                wishlistItemId);
        }
    }
}