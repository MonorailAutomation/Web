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
    }
}