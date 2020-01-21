namespace Platform2DUtils.GameplaySystem
{
    using UnityEngine;

    public class GameplaySystem
    {
        ///<summary>
        /// Returns a Vector2 with the axes Horizontal and Vertical.
        ///</summary>
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        ///<summary>
        /// Returns is jump button was keydown.
        ///</summary>
        public static bool JumpButton
        {
            get => Input.GetButtonDown("Jump");
        }

        ///<summary>
        /// Moves the player in Horizontal axis based on move speed coefficient.
        ///</summary>
        ///<param name="t">This is the transform component of the player.</param>
        ///<param name="moveSpeed">This is the move speed coefficient.</param>
        public static void MovementT(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed);
        }

        ///<summary>
        /// Moves the player in Horizontal axis based on move speed coefficient.
        ///</summary>
        ///<param name="t">This is the transform component of the player.</param>
        ///<param name="moveSpeed">This is the move speed coefficient.</param>
        public static void MovementTdelta(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        }
    }
}