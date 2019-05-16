using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NginxDash.Models;
using NginxDash.Services;
using Renci.SshNet;

namespace NginxDash.Controllers
{
    [Route("_api/[controller]")]
    public class SshController : Controller
    {

    }
}