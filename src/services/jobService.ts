import axios from 'axios';
import {DtoJob} from "../dtos/DtoJob.ts";
import * as signalR from '@microsoft/signalr';
const BASE_URL = 'http://localhost:5217/api';

const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5217/jobHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().catch(err => console.error('SignalR Connection Error: ', err));

const jobService = {
    getMetiers: async (name: string) => {
        try {
            const response = await fetch(`${BASE_URL}/aimodel/${name}/stream`);
            if (!response.body) throw new Error("Réponse vide");

            const reader = response.body.getReader();
            const decoder = new TextDecoder();

            while (true) {
                const { done, value } = await reader.read();
                if (done) break;

                const chunk = decoder.decode(value, { stream: true });
                console.log("Chunk reçu :", chunk);
            }

            console.log("Streaming terminé !");
        } catch (error) {
            console.error("Erreur lors de l’appel à l’API:", error);
        }
    },
};



export default jobService;