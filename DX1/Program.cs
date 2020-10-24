using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Windows;
using static DX1.Fonts;
namespace DX1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Make Window
            RenderForm form = new RenderForm("DirectX C#")
            {
                Size = new System.Drawing.Size(1200,800),
            };
            int width = form.ClientSize.Width;
            int height = form.ClientSize.Height;

            //Setup Device
            Direct3D direct3D = new Direct3D();
            Device device = new Device(
                direct3D,
                0,
                DeviceType.Hardware,
                form.Handle,
                CreateFlags.HardwareVertexProcessing,
                new PresentParameters(width, height) 
                { PresentationInterval = PresentInterval.One } );

            Font Arial = new Font(device, fonArial);

            var fonDimX = Arial.MeasureText(null, "Hey Jeremy                                                                                                                                                                                                               -", new Rectangle(0, 0, width, height), FontDrawFlags.Top | FontDrawFlags.Left);
            var fonDimY = Arial.MeasureText(null, "Hey Jeremy                                                                                                                                                                                                               -", new Rectangle(0, 30, width, height), FontDrawFlags.Top | FontDrawFlags.Left);
            var fonDimZ = Arial.MeasureText(null, "Hey Jeremy                                                                                                                                                                                                               -", new Rectangle(0, 60, width, height), FontDrawFlags.Top | FontDrawFlags.Left);
            var fonDimW = Arial.MeasureText(null, "Hey Jeremy                                                                                                                                                                                                               -", new Rectangle(0, 90, width, height), FontDrawFlags.Top | FontDrawFlags.Left);

            int xDir = 1;
            int yDir = 1;

            // Creates the VertexBuffer
            var vertices = new VertexBuffer(device, Utilities.SizeOf<Vector4>() * 2 * 36, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
            vertices.Lock(0, 0, LockFlags.None).WriteRange(new[]
                                  {
                                      new Vector4(-1.0f, -1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1.0f), // Front
                                      new Vector4(-1.0f,  1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f,  1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1.0f),
                                      new Vector4(-1.0f, -1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f,  1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f, -1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1.0f),

                                      new Vector4(-1.0f, -1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 0.0f, 1.0f), // BACK
                                      new Vector4( 1.0f,  1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4(-1.0f,  1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4(-1.0f, -1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f, -1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f,  1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 0.0f, 1.0f),

                                      new Vector4(-1.0f, 1.0f, -1.0f,  1.0f), new Vector4(0.0f, 0.0f, 1.0f, 1.0f), // Top
                                      new Vector4(-1.0f, 1.0f,  1.0f,  1.0f), new Vector4(0.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f, 1.0f,  1.0f,  1.0f), new Vector4(0.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4(-1.0f, 1.0f, -1.0f,  1.0f), new Vector4(0.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f, 1.0f,  1.0f,  1.0f), new Vector4(0.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f, 1.0f, -1.0f,  1.0f), new Vector4(0.0f, 0.0f, 1.0f, 1.0f),

                                      new Vector4(-1.0f,-1.0f, -1.0f,  1.0f), new Vector4(1.0f, 1.0f, 0.0f, 1.0f), // Bottom
                                      new Vector4( 1.0f,-1.0f,  1.0f,  1.0f), new Vector4(1.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4(-1.0f,-1.0f,  1.0f,  1.0f), new Vector4(1.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4(-1.0f,-1.0f, -1.0f,  1.0f), new Vector4(1.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f,-1.0f, -1.0f,  1.0f), new Vector4(1.0f, 1.0f, 0.0f, 1.0f),
                                      new Vector4( 1.0f,-1.0f,  1.0f,  1.0f), new Vector4(1.0f, 1.0f, 0.0f, 1.0f),

                                      new Vector4(-1.0f, -1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 1.0f, 1.0f), // Left
                                      new Vector4(-1.0f, -1.0f,  1.0f, 1.0f), new Vector4(1.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4(-1.0f,  1.0f,  1.0f, 1.0f), new Vector4(1.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4(-1.0f, -1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4(-1.0f,  1.0f,  1.0f, 1.0f), new Vector4(1.0f, 0.0f, 1.0f, 1.0f),
                                      new Vector4(-1.0f,  1.0f, -1.0f, 1.0f), new Vector4(1.0f, 0.0f, 1.0f, 1.0f),

                                      new Vector4( 1.0f, -1.0f, -1.0f, 1.0f), new Vector4(0.0f, 1.0f, 1.0f, 1.0f), // Right
                                      new Vector4( 1.0f,  1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f, -1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f, -1.0f, -1.0f, 1.0f), new Vector4(0.0f, 1.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f,  1.0f, -1.0f, 1.0f), new Vector4(0.0f, 1.0f, 1.0f, 1.0f),
                                      new Vector4( 1.0f,  1.0f,  1.0f, 1.0f), new Vector4(0.0f, 1.0f, 1.0f, 1.0f),
                            });
            vertices.Unlock();

            // Compiles the effect
            var effect = Effect.FromFile(device, "MiniCube.fx", ShaderFlags.None);

            // Allocate Vertex Elements
            var vertexElems = new[] {
                new VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                new VertexElement(0, 16, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                VertexElement.VertexDeclarationEnd
            };

            // Creates and sets the Vertex Declaration
            var vertexDecl = new VertexDeclaration(device, vertexElems);
            device.SetStreamSource(0, vertices, 0, Utilities.SizeOf<Vector4>() * 2);
            device.VertexDeclaration = vertexDecl;

            // Get the technique
            var technique = effect.GetTechnique(0);
            var pass = effect.GetPass(technique, 0);

            // Prepare matrices
            var view = Matrix.LookAtLH(new Vector3(0, 0, -5), new Vector3(0, 0, 0), Vector3.UnitY);
            var proj = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, form.ClientSize.Width / (float)form.ClientSize.Height, 0.1f, 100.0f);
            var viewProj = Matrix.Multiply(view, proj);

            // Use clock
            var clock = new Stopwatch();
            clock.Start();

            RenderLoop.Run(form, () =>
            {
                var time = clock.ElapsedMilliseconds / 1000.0f;

                device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
                device.BeginScene();

                // Draw the text
                

                effect.Technique = technique;
                effect.Begin();
                effect.BeginPass(0);

                var worldViewProj = Matrix.RotationX(time) * Matrix.RotationY(time * 2) * Matrix.RotationZ(time * .7f) * viewProj;
                Arial.DrawText(null, "SquareX: " + Matrix.RotationX(time).ToString(), fonDimX, FontDrawFlags.Top | FontDrawFlags.Left, Color.Yellow);
                Arial.DrawText(null, "SquareY: " + Matrix.RotationY(time * 2).ToString(), fonDimY, FontDrawFlags.Top | FontDrawFlags.Left, Color.Yellow);
                Arial.DrawText(null, "SquareZ: " + Matrix.RotationZ(time * .7f).ToString(), fonDimZ, FontDrawFlags.Top | FontDrawFlags.Left, Color.Yellow);
                Arial.DrawText(null, "WorldView: " + worldViewProj.ToString(), fonDimW, FontDrawFlags.Top | FontDrawFlags.Left, Color.Yellow);
                effect.SetValue("worldViewProj", worldViewProj);

                device.DrawPrimitives(PrimitiveType.TriangleList, 0, 12);

                effect.EndPass();
                effect.End();

                device.EndScene();
                device.Present();
            });
            effect.Dispose();
            vertices.Dispose();
            device.Dispose();
            direct3D.Dispose();
        }
    }
}
