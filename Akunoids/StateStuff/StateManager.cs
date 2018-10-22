using Microsoft.Xna.Framework;

namespace Akunoids.StateStuff
{
    public class StateManager : DrawableGameComponent
    {
        private IGameState _activeState;
        private IGameState _pausedState;
        private readonly Game _game;

        public StateManager(Game game) : base(game)
        {
            _game = game;
            _activeState = new BoardState(game, this);
            _activeState.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _activeState.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _activeState.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void ChangeState()
        {
            if (_activeState is BoardState)
            {
                _pausedState = _activeState;
                _activeState = new MenuState(_game, this);
                _activeState.LoadContent();
            }
            else
            {
                if (_pausedState == null)
                {
                    _activeState = new BoardState(_game, this);
                    _activeState.LoadContent();
                }
                else
                {
                    _activeState = _pausedState;
                    _pausedState = null;
                }
            }
        }
    }
}
