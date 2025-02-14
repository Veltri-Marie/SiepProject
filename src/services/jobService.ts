import axios from 'axios';
import {DtoJob} from "../dtos/DtoJob.ts";

const BASE_URL = 'http://localhost:5217/api';

const jobService = {
    getMetiers: async (name: string): Promise<DtoJob> => {
        try {
            const response = await axios.get<DtoJob>(`${BASE_URL}/aimodel/${name}`);
            console.log("reponse de l'API" + response.data);
            return response.data;
        } catch (error) {
            console.error('Erreur lors de l’appel à l’API:', error);
            throw error;
        }
    }
};

export default jobService;