import ChatBot from "../components/chatBox/ChatBot.tsx";
import useJobGeneration from "../hooks/useJobGeneration.ts";
import LoadingOrError from "../components/loadingOrError/LoadingOrError.tsx";
import JobEdition from "../components/jobEdition/JobEdition.tsx";
import {StyledMain} from "./GenerationPage.styles.ts";

const GenerationPage = () => {
    const { jobData, setJobData, isLoading, error, fetchMetier } = useJobGeneration();

    return(
        <StyledMain>
            <ChatBot fetchMetier={fetchMetier} />
            <LoadingOrError isLoading={isLoading} error={error} />
            {!isLoading && !error && jobData != undefined && (
                <JobEdition jobData={jobData} setJobData={setJobData}/>
            )}
        </StyledMain>
    )
}

export default GenerationPage;