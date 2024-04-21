using System.Reflection;

namespace SplotchLib
{
    /// <summary>
    /// Basic Utility functions. If you feel like there is a function that should be in here create an issue on github.
    /// </summary>
    public class SplotchUtils
    {
        /// <summary>
        /// Retrieves the <c>Player</c> corresponding to a <c>PlayerBody</c>
        /// </summary>
        /// <param name="playerBody">The <c>PlayerBody</c> object</param>
        /// <returns>The corresponding <c>Player</c> object</returns>
        public static Player GetPlayerFromPlayerBody(PlayerBody playerBody)
        {
            FieldInfo type = typeof(PlayerBody).GetField("idHolder", BindingFlags.NonPublic | BindingFlags.Instance);
            IPlayerIdHolder idHolder = (IPlayerIdHolder)type.GetValue(playerBody);
            Player player = PlayerHandler.Get().GetPlayer(idHolder.GetPlayerId());
            return player;
        }
    }
}
