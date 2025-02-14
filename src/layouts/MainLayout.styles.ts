import { styled } from '@mui/system';
import { Box } from '@mui/material';
import React from "react";

export const Container = styled(Box)(() => ({
    display: 'flex',
    minHeight: '100vh',
    backgroundColor: '#f4f4f4',
}));

export const MainContent = styled(Box)<{ component?: React.ElementType }>(({ theme }) => ({
    padding: theme.spacing(3),
    paddingTop: '64px',
}));

