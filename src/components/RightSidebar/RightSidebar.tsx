import React from "react";
import { Box, TextField, Typography, Paper } from "@mui/material";
import { DtoJob } from "../../Dtos/DtoJob.ts";

interface RightSidebarProps {
    setJobData: (value: DtoJob) => void;
    jobData?: DtoJob;
}

const RightSidebar: React.FC<RightSidebarProps> = ({ jobData, setJobData }) => {
    if (!jobData) {
        return null;
    }

    return (
        <Paper
            elevation={3}
            sx={{
                flex: 1,
                padding: 3,
                borderRadius: "8px",
                backgroundColor: "#fff",
                minWidth: "300px",
                maxWidth: "400px",
                height: "fit-content",
                alignSelf: "flex-start",
            }}
        >
            <Typography variant="h5" sx={{ mb: 2, fontWeight: "bold" }}>Fiche Métier</Typography>

            <TextField
                label="Nom *"
                fullWidth
                variant="outlined"
                margin="normal"
                value={jobData.name || ""}
                onChange={(e) => setJobData({ ...jobData, name: e.target.value })}
            />

            <TextField
                label="Identifiant *"
                type="number"
                fullWidth
                variant="outlined"
                margin="normal"
                value={jobData.id || ""}
                onChange={(e) => setJobData({ ...jobData, id: Number(e.target.value) || 0 })}
            />

            <TextField
                label="Extrait"
                fullWidth
                multiline
                rows={3}
                variant="outlined"
                margin="normal"
                value={jobData.excerpt || ""}
                onChange={(e) => setJobData({ ...jobData, excerpt: e.target.value })}
            />

            <TextField
                label="Tags"
                fullWidth
                variant="outlined"
                margin="normal"
                value={jobData.tags ? jobData.tags.join(", ") : ""}
                onChange={(e) =>
                    setJobData({
                        ...jobData,
                        tags: e.target.value.split(",").map((tag) => tag.trim()),
                    })
                }
            />
        </Paper>
    );
};

export default RightSidebar;
