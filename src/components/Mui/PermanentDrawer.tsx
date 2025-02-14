import { useState } from "react";
import {
    Box,Toolbar, Typography,CircularProgress
} from "@mui/material";
import ChatBot from "../Chatbox/ChatBot.tsx";
import { DtoJob } from "../../Dtos/DtoJob.ts";

import jobService from "../../services/JobService.ts";
import JobEditor from "../JobEditor/JobEditor.tsx";
import RightSidebar from "../RightSidebar/RightSidebar.tsx";

export default function PermanentDrawerLeft() {
    const [jobData, setJobData] = useState<DtoJob | undefined>(undefined);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const fetchMetier = async (name: string) => {
        if (!name.trim()) {
            setError("Veuillez entrer un métier à recherche.");
            return;
        }

        setIsLoading(true);
        setError("");

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

    return(
        <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
            <Toolbar />
            <ChatBot fetchMetier={fetchMetier} />
            {isLoading ? (
                <Box sx={{ display: "flex", justifyContent: "center", mt: 3 }}>
                    <CircularProgress size={50} color="primary" />
                </Box>
            ) : error ? (
                <Typography color="error">{error}</Typography>
            ) : (
                <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "flex-start", gap: 3 }}>
                    <Box sx={{ flex: 2 }}>
                        <JobEditor jobData={jobData} setJobData={setJobData} />
                    </Box>

                    {/* Sidebar bien alignée */}
                    <Box sx={{ flex: 1, maxWidth: "400px" }}>
                        <RightSidebar jobData={jobData} setJobData={setJobData} />
                    </Box>
                </Box>
            )}
        </Box>
    )
}
