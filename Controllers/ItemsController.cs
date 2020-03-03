using Api1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/players/{playerId}/items")]
    public class ItemsController : ControllerBase
    {
        // Get Items
        [HttpGet]
        public IActionResult GetItems(int playerId)
        {
            var player = PlayersDataStore.Current.Players.
                FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player.Item);
        }

        // Get Item
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetItem(int playerId, int id)
        {
            var player = PlayersDataStore.Current.Players.
                FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return NotFound();
            }

            var item = player.Item.
                FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

            //var item = PlayersDataStore.Current.Players.
            //    FirstOrDefault(p => p.Id == playerId)?.Item.
            //    FirstOrDefault(i => i.Id == id);

            //return item == null
            //    ? (IActionResult)NotFound()
            //    : Ok(item);
        }

        // Create Item
        [HttpPost]
        public IActionResult CreateItem(int playerId,
            [FromBody] ItemCreateDto item)
        {
            var player = PlayersDataStore.Current.Players.
                FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return NotFound();
            }

            var maxItemId = PlayersDataStore.Current.Players.
                SelectMany(p => p.Item).Max(i => i.Id);

            var finalItem = new ItemDto()
            {
                Id = ++maxItemId,
                Name = item.Name,
                Value = item.Value
            };

            player.Item.Add(finalItem);

            return CreatedAtRoute(
                "GetItem",
                new { playerId, id = finalItem.Id },
                finalItem
            );
        }

        // Put = override; Patch = update;
        // Update Item
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int playerId, int id,
            [FromBody] ItemUpdateDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var player = PlayersDataStore.Current.Players.
                FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return NotFound();
            }

            var itemFromStore = player.Item.
                FirstOrDefault(i => i.Id == id);

            if (itemFromStore == null)
            {
                return NotFound();
            }

            itemFromStore.Name = item.Name;
            itemFromStore.Value = item.Value;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateItem(int playerId, int id,
            [FromBody] JsonPatchDocument<ItemUpdateDto> pathDoc)
        {
            var player = PlayersDataStore.Current.Players.
                FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return NotFound();
            }

            var itemFromStore = player.Item.
                FirstOrDefault(i => i.Id == id);

            if (itemFromStore == null)
            {
                return NotFound();
            }

            var itemToPatch =
                new ItemUpdateDto()
                {
                    Name = itemFromStore.Name,
                    Value = itemFromStore.Value
                };

            pathDoc.ApplyTo(itemToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(itemToPatch))
            {
                return BadRequest(ModelState);
            }

            itemFromStore.Name = itemToPatch.Name;
            itemFromStore.Value = itemToPatch.Value;

            return NoContent();
        }

        // Delete Item
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int playerId, int id)
        {
            var player = PlayersDataStore.Current.Players.
                FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return NotFound();
            }

            var item = player.Item.
                FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            player.Item.Remove(item);

            return Ok(item);
        }
    }
}
