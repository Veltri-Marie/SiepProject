import { useState } from "react";
import { DtoJob } from "../dtos/DtoJob";
import jobService from "../services/jobService.ts";

const useJobGeneration = () => {
    const [jobData, setJobData] = useState<DtoJob | undefined>(undefined);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const fetchMetier = async (name: string) => {
        if (!name.trim()) {
            setError("Veuillez entrer un métier à rechercher.");
            return;
        }

        setIsLoading(true);
        setError(null);

        try {
            const job = await jobService.getMetiers(name);
            setJobData(job);
        } catch {
            setError("Aucun métier trouvé.");
            setJobData(undefined);
        } finally {
            setIsLoading(false);
        }
    };

    return { jobData, setJobData, isLoading, error, fetchMetier };
};

export default useJobGeneration;
