import React from "react";
import JobEditor from "../jobEditor/JobEditor.tsx";
import RightSidebar from "../rightSideBar/RightSidebar.tsx";
import { DtoJob } from "../../dtos/DtoJob.ts";
import { StyledContainer, StyledEditorWrapper, StyledSidebarWrapper } from "./JobEdition.styles.ts";

interface JobEditionProps {
    jobData: DtoJob | undefined;
    setJobData: (data: DtoJob | undefined) => void;
}

const JobEdition: React.FC<JobEditionProps> = ({ jobData, setJobData }) => {
    return (
        <StyledContainer>
            <StyledEditorWrapper>
                <JobEditor jobData={jobData} setJobData={setJobData} />
            </StyledEditorWrapper>
            <StyledSidebarWrapper>
                <RightSidebar jobData={jobData} setJobData={setJobData} />
            </StyledSidebarWrapper>
        </StyledContainer>
    );
};

export default JobEdition;
