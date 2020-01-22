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
        /// Returns a Vector2 with the axes Horizontal and Vertical mutiplied by delta time.
        ///</summary>
        public static Vector2 AxisDelta
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * Time.deltaTime);
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

        ///<summary>
        /// Moves the player with addforce on x axis.
        ///</summary>
        ///<param name="rb2d">This is the Rigidbody2D component of the player.</param>
        ///<param name="moveSpeed">This is the move speed coefficient.</param>
        ///<param name="maxVelX">This is the max velocity on x axis of the player.</param>
        public static void PhysicsMovement(Rigidbody2D rb2d, float moveSpeed, float maxVelX)
        {
            rb2d.AddForce(Vector2.right * AxisDelta.x, ForceMode2D.Impulse);
            rb2d.velocity = new Vector2( Vector2.ClampMagnitude(rb2d.velocity, maxVelX).x, rb2d.velocity.y);
        }

        ///<summary>
        /// Moves the player with velocity on x axis.
        ///</summary>
        ///<param name="rb2d">This is the Rigidbody2D component of the player.</param>
        ///<param name="moveSpeed">This is the move speed coefficient.</param>
        ///<param name="maxVelX">This is the max velocity on x axis of the player.</param>
        public static void PhysicsMovementVel(Rigidbody2D rb2d, float moveSpeed, float maxVelX)
        {
            rb2d.velocity = new Vector2(AxisDelta.x * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = new Vector2( Vector2.ClampMagnitude(rb2d.velocity, maxVelX).x, rb2d.velocity.y);
        }
    }
}