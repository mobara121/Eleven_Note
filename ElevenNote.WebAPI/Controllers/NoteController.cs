﻿using ElevenNote.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        //Get(GET) All
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }

        //Get(GET) by Id
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }

        public IHttpActionResult Post(NoteCreate note)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateNoteService();

            if (!service.CreateNote(note))
            {
                return InternalServerError();
            }
            return Ok();
        }

        //to allow us to use our NoteService in methods above.
        private NoteService CreateNoteService() 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }

    }
}
