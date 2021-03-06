﻿using Grpc.Net.Client;
using System;
using Google.Protobuf.WellKnownTypes;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcService;
using static GrpcDatabase.DataBaseContext;

namespace GrpcClient
{
    public class Program
    {
            static async Task Main(string[] args)
            {
                Console.WriteLine("Client GRPC");

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                var client = new GrpcClient(GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = new HttpClient(httpClientHandler) }));
            
            //await Add(client);
            //await ShowAll(client);
            Console.ReadKey();
            }

            static async Task Add(GrpcClient client)
            {
                PostRequest postRequest = new PostRequest() { Domain = "Domain-Name", Description = "Description-Name" };
                postRequest.Comments.Add(new CommentRequest() { Text = "Comment 1" });
                postRequest.Comments.Add(new CommentRequest() { Text = "Comment 2" });

                var reply = await client.AddPostAsync(postRequest);

                DisplayPostResponse(reply);
            }

            static async Task ShowAll(GrpcClient client)
            {
                var reply = await client.GetAllPostsAsync(new Empty());

                foreach (var post in reply.Posts)
                {
                    DisplayPostResponse(post);
                }
            }

            static void DisplayPostResponse(PostResponse post)
            {
                Console.WriteLine("{0}, {1}, {2}", post.Domain, post.Description, post.Date.ToDateTime());
                Console.WriteLine("Comentarii:");
                if (post.Comments.Count > 0)
                {
                    foreach (var comment in post.Comments)
                        Console.WriteLine("\tId : {0}\n\tCom: {1}", comment.CommentId, comment.Text);
                }
            }
        }
    }
