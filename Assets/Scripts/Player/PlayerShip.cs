namespace SpaceWars
{
    public class PlayerShip : SpaceShip
    {
        private LevelLoader _levelLoader;

        private void Start() => _levelLoader = FindObjectOfType<LevelLoader>();

        protected override void Die()
        {
            base.Die();
            _levelLoader.LoadGameOverScene();
        }
    }
}