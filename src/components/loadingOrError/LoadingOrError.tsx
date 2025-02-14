import React from "react";
import { CircularProgress, Typography } from "@mui/material";
import { StyledLoadingContainer } from "./LoadingOrError.styles";

interface LoadingOrErrorProps {
    isLoading: boolean;
    error: string | null;
}

const LoadingOrError: React.FC<LoadingOrErrorProps> = ({ isLoading, error }) => {
    if (isLoading) {
        return (
            <StyledLoadingContainer>
                <CircularProgress size={50} color="primary" />
            </StyledLoadingContainer>
        );
    }

    if (error) {
        return <Typography color="error">{error}</Typography>;
    }

    return null;
};

export default LoadingOrError;
