using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MvcSchool.Web.Models.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Hubs
{
    [Authorize]
    public class CanvasHub : Hub
    {
        public async Task SendDrawingToAllCSharp(int xCoord, int yCoord, string brSize, string brColor)
        {
            int brushSize = 20;          
            if (brSize != "Choose brush size...")
            {
                brushSize = int.Parse(brSize);
            }

            string brushColor = brColor;
            if (brushColor == "Choose brush color...")
            {
                brushColor = "black";
            }

            var model = new CanvasDrawingViewModel
            {
                xCoordinate = xCoord,
                yCoordinate = yCoord,
                brushColor = brushColor,
                brushSize = brushSize
                //zero = zero,
            };
            await this.Clients.All.SendAsync("SendDrawingToAllJS", model);
        }
    }
}
