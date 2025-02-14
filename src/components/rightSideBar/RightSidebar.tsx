import React from "react";
import { DtoJob } from "../../dtos/DtoJob.ts";
import { StyledPaper, StyledTypography, StyledTextField } from "./RightSideBar.styles.ts";

interface RightSidebarProps {
    setJobData: (value: DtoJob) => void;
    jobData?: DtoJob;
}

const RightSidebar: React.FC<RightSidebarProps> = ({ jobData, setJobData }) => {
    if (!jobData) {
        return null;
    }

    return (
        <StyledPaper elevation={3}>
            <StyledTypography variant="h5">Fiche Métier</StyledTypography>

            <StyledTextField
                label="Nom *"
                fullWidth
                variant="outlined"
                value={jobData.name || ""}
                onChange={(e) => setJobData({ ...jobData, name: e.target.value })}
            />

            <StyledTextField
                label="Identifiant *"
                type="number"
                fullWidth
                variant="outlined"
                value={jobData.id || ""}
                onChange={(e) => setJobData({ ...jobData, id: Number(e.target.value) || 0 })}
            />

            <StyledTextField
                label="Extrait"
                fullWidth
                multiline
                rows={3}
                variant="outlined"
                value={jobData.excerpt || ""}
                onChange={(e) => setJobData({ ...jobData, excerpt: e.target.value })}
            />

            <StyledTextField
                label="Tags"
                fullWidth
                variant="outlined"
                value={jobData.tags ? jobData.tags.join(", ") : ""}
                onChange={(e) =>
                    setJobData({
                        ...jobData,
                        tags: e.target.value.split(",").map((tag) => tag.trim()),
                    })
                }
            />
        </StyledPaper>
    );
};

export default RightSidebar;
