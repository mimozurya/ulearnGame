using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kroshka_Adventure
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        // Позволяет получить доступ к графическому устройству компьютера,
        // смартфона, планшета, игровой консоли
        // Объект GraphicsDeviceManager является проводником между игрой и
        // видеокартой, и вся отрисовка в игре будет проходить через этот объект.
        SpriteBatch spriteBatch;
        // служит для отрисовки спрайтов - изображений, которые используются в игре.


        // В конструкторе класса Game1 и методе Initialize происходит начальная
        // инициализации используемых переменных и объектов.
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        // предназначен для загрузки ресурсов, которые применяются в игре -
        // аудиофайлов, файлов изображений и так далее.
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        // Методы Update() и Draw() представляют игровой цикл.
        // Оба метода принимают в качестве параметра объект GameTime - он
        // хранит время, прошедшее с начала игры.

        // Метод Update() отвечает за логику игры, производит вычисления: обновляет
        // позиции персонажей и так далее. По умолчанию все его действие сводится к
        // проверке нажатой пользователем клавиши:
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        // Метод Draw() выполняет перерисовку экрана. Например, в методе Update обновляется
        // позиция персонажа, а в методе Draw() происходит перерисовка персонажа на основе
        // новой позиции. При этом важно учитывать, что все вычисления должны находиться в
        // методе Update. Задача метода Draw - только перерисовка.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}